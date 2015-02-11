using System;
using Enigma;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enigma.Test
{
	[TestClass]
	public class EnigmaTest
	{
		[TestMethod]
		public void TestParser()
		{
			string input = "ENIGMA REVEALED";

			EnigmaMachine machine = new EnigmaMachine();
			machine.Reflector = new Reflector("ABCDEFGDIJKGMKMIEBFTCVVJAT");

			machine.RotorLeft = new Rotor("EKMFLGDQVZNTOWYHXUSPAIBRCJ", 'Q');
			machine.RotorLeft.SetPosition('M');

			machine.RotorCenter = new Rotor("AJDKSIRUXBLHWTMCQGZNPYFVOE", 'E');
			machine.RotorCenter.SetPosition('C');

			machine.RotorRight = new Rotor("BDFHJLCPRTXVZNYEIWGAKMUSQO", 'W');
			machine.RotorRight.SetPosition('K');

			string result = machine.Parse(input);

			Assert.AreEqual("QMJIDO MZWZJFJR", result);
		}
	}
}
