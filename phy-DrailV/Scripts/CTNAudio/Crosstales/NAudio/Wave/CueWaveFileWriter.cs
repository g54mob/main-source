using System.IO;

namespace Crosstales.NAudio.Wave
{
	public class CueWaveFileWriter : WaveFileWriter
	{
		private CueList cues;

		public CueWaveFileWriter(string fileName, WaveFormat waveFormat)
			: base(fileName, waveFormat)
		{
		}

		public void AddCue(int position, string label)
		{
			if (cues == null)
			{
				cues = new CueList();
			}
			cues.Add(new Cue(position, label));
		}

		private void WriteCues(BinaryWriter w)
		{
			if (cues != null)
			{
				int count = cues.GetRIFFChunks().Length;
				w.Seek(0, SeekOrigin.End);
				w.Write(cues.GetRIFFChunks(), 0, count);
				w.Seek(4, SeekOrigin.Begin);
				w.Write((int)(w.BaseStream.Length - 8));
			}
		}

		protected override void UpdateHeader(BinaryWriter writer)
		{
			base.UpdateHeader(writer);
			WriteCues(writer);
		}
	}
}
