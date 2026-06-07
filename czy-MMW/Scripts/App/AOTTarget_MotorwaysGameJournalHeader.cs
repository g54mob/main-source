using System;
using Factory;
using FixMath;
using Motorways;

public static class AOTTarget_MotorwaysGameJournalHeader
{
	public static void DontCall_AOTWorkaround()
	{
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<MotorwaysGameJournalHeader, GameJournalMotive>();
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<MotorwaysGameJournalHeader, string>();
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<MotorwaysGameJournalHeader, DateTime>();
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<MotorwaysGameJournalHeader, int>();
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<MotorwaysGameJournalHeader, GameMode>();
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<MotorwaysGameJournalHeader, Fix64>();
		Assembler.DontCall_EnsureAOTGenericCallsAreCompiled<MotorwaysGameJournalHeader, MapChallenge.ChallengeType>();
	}
}
