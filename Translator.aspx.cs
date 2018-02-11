using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticeProject
{
    public partial class PigLatinTranslator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void translateButton_Click(object sender, EventArgs e)
        {
            TextInfo myTI = new CultureInfo("en-us", false).TextInfo;

            string first = firstName.Text.ToString();
            string last = lastName.Text.ToString();

            Word firstWord = new Word();
            int firstIndex = firstWord.VowelIndex(first);
            bool firstLetterY = firstWord.lastLetter(first);
            string firstTranslate = firstWord.TranslateTo(first, firstIndex, firstLetterY);

            Word lastWord = new Word();
            int lastIndex = lastWord.VowelIndex(last);
            bool lastLetterY = lastWord.lastLetter(last);
            string lastTranslate = lastWord.TranslateTo(last, lastIndex, lastLetterY);

            Result.Text = ($"{myTI.ToUpper(firstTranslate)} {myTI.ToUpper(lastTranslate)}");

        }

    }



    public class Word
    {
        string WordString { get; set; }
        int FirstVowelIndex { get; set; }
        string Translation { get; set; }

        //Find first instance of vowel in string
        public int VowelIndex(string nameString)
        {
            //Convert string to lower case for proper comparison with List<string> vowels
            string nameStringLower = nameString.ToLower();

            List<string> vowels = new List<string>{
                "a", "e","i","o","u","y"
            };

            List<int> firstVowels = new List<int>();

            //Only add vowels to list that are in word
            foreach (var item in vowels)
            {
                if (nameStringLower.IndexOf(item) >= 0)
                {
                    firstVowels.Add(nameStringLower.IndexOf(item));
                }
            }

            FirstVowelIndex = firstVowels.Min();
            return FirstVowelIndex;
        }

        //Determine if last letter of word is Y
        public bool lastLetter(string nameString)
        {
            bool endsInY;
            int lastIndex = nameString.LastIndexOf("y");
            int stringLength = nameString.Length - 1;
            if (lastIndex == stringLength)
            {
                endsInY = true;
            }
            else
            {
                endsInY = false;
            }
            return endsInY;
        }


        //Create pig latin string
        public string TranslateTo(string nameString, int FirstVowelIndex, bool lastLetter)
        {
            if (FirstVowelIndex == 0 && lastLetter == false)
            {
                string endingPart = "yay";
                string translation = String.Concat(nameString, endingPart);
                return translation;
            }

            else if (FirstVowelIndex == 0 && lastLetter == true)
            {
                string endingPart = "ay";
                string translation = String.Concat(nameString, endingPart);
                return translation;
            }

            else
            {

                string firstPart = nameString.Remove(FirstVowelIndex);
                string lastPart = nameString.Remove(0, FirstVowelIndex);
                string endingPart = "ay";
                string translation = String.Concat(lastPart, firstPart, endingPart);
                return translation;
            }
        }
    }

};
















