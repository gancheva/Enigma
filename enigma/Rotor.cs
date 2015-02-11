using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enigma
{
	public class Rotor
	{
		protected List<CharacterCombination> characters;

		public Rotor(string rotorString, char tippingChar)
		{
			string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

			this.characters = new List<CharacterCombination>();
			for (int i = 0; i < alphabet.Length; i++)
			{
				this.characters.Add(new CharacterCombination(alphabet[i], rotorString[i], alphabet[i] == tippingChar));
			}
		}

		public void SetPosition(char position)
		{
			for (int i = 0; i < this.characters.Count; i++)
			{
				if (this.characters[0].Left == position)
					return;

				this.MoveUp();
			}
		}

		public bool MoveUp()
		{
			CharacterCombination combination = this.characters[0];
			this.characters.RemoveAt(0);
			this.characters.Add(combination);
			return this.characters[0].IsTippingChar;
		}

		public char GetCharByIndexToLeft(int index)
		{
			return this.characters[index].Right;
		}

		public char GetCharByIndexToRight(int index)
		{
			return this.characters[index].Left;
		}

		public int GetIndexToLeft(char characterRight)
		{
			for (int i = 0; i < this.characters.Count; i++)
			{
				if (this.characters[i].Left == characterRight)
				{
					return i;
				}
			}

			throw new MatchNotFoundException();
		}

		public int GetIndexToRight(char characterLeft)
		{
			for (int i = 0; i < this.characters.Count; i++)
			{
				if (this.characters[i].Right == characterLeft)
				{
					return i;
				}
			}

			throw new MatchNotFoundException();
		}
	}

	[Serializable]
	public class MatchNotFoundException : Exception
	{
		public MatchNotFoundException() { }
		public MatchNotFoundException(string message) : base(message) { }
		public MatchNotFoundException(string message, Exception inner) : base(message, inner) { }
		protected MatchNotFoundException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context)
			: base(info, context) { }
	}

	public class CharacterCombination
	{
		public char Left { get; protected set; }
		public char Right { get; protected set; }

		public bool IsTippingChar { get; protected set; }

		public CharacterCombination(char left, char right, bool isTippingChar)
		{
			this.Left = left;
			this.Right = right;
			this.IsTippingChar = isTippingChar;
		}
	}
}
