using System;
using System.IO;
using System.Text;
using Restory.Constants;

namespace Restory.Data.SaveLoad
{
	public class SaveFileVersionReader
	{
		private readonly byte[] projectMark;

		private readonly int projectMarkLength;

		public SaveFileVersionReader()
		{
			projectMark = Encoding.ASCII.GetBytes(ProjectConstants.Infrastructure.ProjectTag);
			projectMarkLength = projectMark.Length;
		}

		public int ReadSaveFileVersion(string filePath)
		{
			try
			{
				using FileStream input = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
				using BinaryReader binaryReader = new BinaryReader(input, Encoding.UTF8);
				if (!binaryReader.ReadBytes(projectMarkLength).AsSpan().SequenceEqual(projectMark))
				{
					return 0;
				}
				return binaryReader.ReadInt32();
			}
			catch
			{
				return 0;
			}
		}
	}
}
