using System;
using System.IO;
using System.Linq;
using Factory;
using JetBrains.Annotations;

namespace Motorways.Views
{
	public class ArchivedSavedGame
	{
		private readonly string _path;

		public string Name { get; }

		public MotorwaysGameJournalSave SavedGame { get; private set; }

		public ArchivedSavedGame(string path, MotorwaysGameJournalSave savedGame)
		{
			_path = path;
			SavedGame = savedGame;
			string text = path.Split(Path.DirectorySeparatorChar).Last();
			Name = (text.Contains('.') ? text.Substring(0, text.LastIndexOf('.')) : "");
		}

		public void Release()
		{
			if (SavedGame != null)
			{
				SavedGame.Scope.Release(SavedGame);
				SavedGame = null;
			}
		}

		public void Delete()
		{
			File.Delete(_path);
		}

		[CanBeNull]
		public static ArchivedSavedGame Load(string path, IScope scope)
		{
			MotorwaysGameJournalSave motorwaysGameJournalSave = scope.Get<MotorwaysGameJournalSave>();
			byte[] buffer;
			try
			{
				buffer = File.ReadAllBytes(path);
			}
			catch (Exception)
			{
				scope.Release(motorwaysGameJournalSave);
				return null;
			}
			using MemoryStream input = new MemoryStream(buffer);
			using BinaryReader binaryReader = new BinaryReader(input);
			if (motorwaysGameJournalSave.ValidateHeader(binaryReader) == IBinarySerializableSaveData.HeaderValidationResult.Success)
			{
				byte[] saveDataAsBytes = binaryReader.ReadBytes((int)(binaryReader.BaseStream.Length - binaryReader.BaseStream.Position));
				motorwaysGameJournalSave.InitializeWithBytes(saveDataAsBytes);
				return new ArchivedSavedGame(path, motorwaysGameJournalSave);
			}
			scope.Release(motorwaysGameJournalSave);
			return null;
		}
	}
}
