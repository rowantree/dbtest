using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace dbtest
{
	class AgeValidation : ValidationRule
	{
		public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
		{
			int age;
			Boolean noIllegalChars = int.TryParse(value.ToString(), out age);

			if (value.ToString().Length < 1)
			{
				return new ValidationResult(false, "Age field cannot be empty");
			}
			else if (noIllegalChars == false)
			{
				return new ValidationResult(false, "Illegal Characters");
			}
			else
			{
				return new ValidationResult(true, null);
			}

		}
	}
}