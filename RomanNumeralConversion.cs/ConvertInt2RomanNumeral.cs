using System;
using System.Linq;
using System.Collections.Generic;
class ConvertInt2RomanNumeral
 {
    static void Main(string[] args)
     {
        Dictionary<int,string> romanNumeral = new Dictionary<int,string>();
            romanNumeral[1] = "I";
            romanNumeral[5] = "V";
            romanNumeral[10] = "X";
            romanNumeral[50] = "L";
            romanNumeral[100] = "C";
            romanNumeral[500] = "D";
            romanNumeral[1000] = "M";

        int inputNum = 0; string userInput = "";
           do  
             {  string finalRomanNumeralOutput = "";
             Console.WriteLine("Enter an Integer between 1 - 3999 to be converted to Roman Numeral");
              userInput = Console.ReadLine();
               if (userInput == "STOP") break;
               if (!(int.TryParse(userInput, out inputNum)))
               {
                  Console.WriteLine("Enter a valid Integer 1 - 3999 , enter \"STOP\" to exit");
                  continue;
               }
               if ( (inputNum > 3999) || (inputNum == 0) )
                  {
                     Console.WriteLine("Enter a valid Integer 1 - 3999 , enter \"STOP\" to exit");
                     continue;
                  }

                  var result = ("",0);
                  do 
                     {
                        result = ClosestNumber(inputNum, romanNumeral);
                        finalRomanNumeralOutput += result.Item1;
                        inputNum = result.Item2;
                     } while (result.Item2 > 0) ;
                  Console.WriteLine($"Roman Numeral for {userInput} = {finalRomanNumeralOutput}\n {string.Concat(Enumerable.Repeat("*",50))}");    

             } while (userInput != "STOP");

        
     }

     static (string outRN, int diff) ClosestNumber(int in1, Dictionary<int,string> romanNumeral) 
       {
         string outRN = "M"; int diff = 0;
         if (in1 >= 1000)
           {
            outRN = "M";
            diff = in1 - 1000;
           } else 
          if ((in1 >=900) && (in1 <= 1000))
           {
            outRN = "CM";
            diff = in1 - 900;
           } else 
          if ((in1 >=400) && (in1 <=490))
           {
            outRN = "CD";
            diff = in1 - 400;
           } else
          if ((in1 >=40) && (in1 <=49))
           {
            outRN = "XL";
            diff = in1-40;
           } else
           if (in1 == 4)
           {
            outRN = "IV";
            diff = 0;
           } else
            {
               int diff1 = 0;string outRN1 = "";
               foreach (var key in romanNumeral.Keys)
                     {
                           diff1 = in1 - key;
                           outRN1 = romanNumeral[key];
                              if (diff1 < 0) break;
                              else
                                {
                                    diff = diff1;
                                    outRN = romanNumeral[key];
                                }   
                     }
            }
            return (outRN, diff);
      }
   }