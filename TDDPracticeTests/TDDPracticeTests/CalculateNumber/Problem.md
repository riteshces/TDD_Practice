﻿# Problem
1. Create a simple String calculator with a method signature:
———————————————
int Add(string numbers)
———————————————
The method can take up to two numbers, separated by commas, and will return their sum. 
for example “” or “1” or “1,2” as inputs.
(for an empty string it will return 0) .

1. Allow the Add method to handle an unknown amount of numbers

1. Allow the Add method to handle new lines between numbers (instead of commas).
a	. the following input is ok: “1\n2,3” (will equal 6)
b	. the following input is NOT ok: “1,\n” (not need to prove it - just clarifying)

1. Support different delimiters 
1	. to change a delimiter, the beginning of the string will contain a separate line that looks like this: “//[delimiter]\n[numbers…]” for example “//;\n1;2” should return three where the default delimiter is ‘;’ .
2	. the first line is optional. all existing scenarios should still be supported

1. Calling Add with a negative number will throw an exception “negatives not allowed” - and the negative that was passed. 
if there are multiple negatives, show all of them in the exception message.