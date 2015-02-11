using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enigma
{
	public class Reflector
	{
		protected string reflectorString;

		public Reflector(string reflectorString)
		{
			this.reflectorString = reflectorString;
		}

		public int Reflect(int index)
		{
			char reflectionChar = this.reflectorString[index];
			int reflectionIndex = this.reflectorString.IndexOf(reflectionChar);

			if (reflectionIndex == index)
				reflectionIndex = this.reflectorString.IndexOf(reflectionChar, index + 1);

			return reflectionIndex;
		}
	}
}
