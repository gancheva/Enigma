using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enigma
{
	public class EnigmaMachine
	{
		public Reflector Reflector { get; set; }

		public Rotor RotorLeft { get; set; }

		public Rotor RotorCenter { get; set; }

		public Rotor RotorRight { get; set; }

		public string Parse(string message)
		{
			string buffer = "";
			string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

			message = message.ToUpper();

			foreach (char character in message)
			{
				if (!alphabet.Contains(character))
				{
					buffer += character;
					continue;
				}

				buffer += this.Parse(character);
			}
			
			return buffer;
		}

		protected char Parse(char character)
		{
			bool tip = this.RotorRight.MoveUp();
			if (tip)
			{
				tip = this.RotorCenter.MoveUp();
				if (tip)
				{
					tip = this.RotorLeft.MoveUp();
				}
			}

			string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			int nextIndex;
			char nextCharacter;

			nextIndex = alphabet.IndexOf(character);

			nextCharacter = this.RotorRight.GetCharByIndexToLeft(nextIndex);
			nextIndex = this.RotorRight.GetIndexToLeft(nextCharacter);

			nextCharacter = this.RotorCenter.GetCharByIndexToLeft(nextIndex);
			nextIndex = this.RotorCenter.GetIndexToLeft(nextCharacter);

			nextCharacter = this.RotorLeft.GetCharByIndexToLeft(nextIndex);
			nextIndex = this.RotorLeft.GetIndexToLeft(nextCharacter);

			nextIndex = this.Reflector.Reflect(nextIndex);

			nextCharacter = this.RotorLeft.GetCharByIndexToRight(nextIndex);
			nextIndex = this.RotorLeft.GetIndexToRight(nextCharacter);

			nextCharacter = this.RotorCenter.GetCharByIndexToRight(nextIndex);
			nextIndex = this.RotorCenter.GetIndexToRight(nextCharacter);

			nextCharacter = this.RotorRight.GetCharByIndexToRight(nextIndex);
			nextIndex = this.RotorRight.GetIndexToRight(nextCharacter);

			return alphabet[nextIndex];
		}
	}
}
