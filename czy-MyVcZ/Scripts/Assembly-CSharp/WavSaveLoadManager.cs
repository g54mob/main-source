using System.IO;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public static class WavSaveLoadManager
{
	public static void Save(AudioClip clip, string filePath)
	{
		float[] array = new float[clip.samples * clip.channels];
		clip.GetData(array, 0);
		byte[] array2 = new byte[array.Length * 2];
		int num = 0;
		float[] array3 = array;
		for (int i = 0; i < array3.Length; i++)
		{
			short num2 = (short)(Mathf.Clamp(array3[i], -1f, 1f) * 32767f);
			array2[num++] = (byte)(num2 & 0xFF);
			array2[num++] = (byte)((num2 >> 8) & 0xFF);
		}
		using FileStream output = new FileStream(filePath, FileMode.Create);
		using BinaryWriter binaryWriter = new BinaryWriter(output);
		int value = clip.frequency * clip.channels * 2;
		int num3 = array2.Length;
		int value2 = 36 + num3;
		binaryWriter.Write(Encoding.ASCII.GetBytes("RIFF"));
		binaryWriter.Write(value2);
		binaryWriter.Write(Encoding.ASCII.GetBytes("WAVE"));
		binaryWriter.Write(Encoding.ASCII.GetBytes("fmt "));
		binaryWriter.Write(16);
		binaryWriter.Write((short)1);
		binaryWriter.Write((short)clip.channels);
		binaryWriter.Write(clip.frequency);
		binaryWriter.Write(value);
		binaryWriter.Write((short)(clip.channels * 2));
		binaryWriter.Write((short)16);
		binaryWriter.Write(Encoding.ASCII.GetBytes("data"));
		binaryWriter.Write(num3);
		binaryWriter.Write(array2);
	}

	public static async Task<AudioClip> Load(string filePath)
	{
		string uri = "file://" + filePath.Replace("\\", "/");
		using UnityWebRequest req = UnityWebRequestMultimedia.GetAudioClip(uri, AudioType.WAV);
		UnityWebRequestAsyncOperation op = req.SendWebRequest();
		while (!op.isDone)
		{
			await Task.Yield();
		}
		if (req.result != UnityWebRequest.Result.Success)
		{
			Debug.LogError("WAV Load Error: " + req.error);
			return null;
		}
		return DownloadHandlerAudioClip.GetContent(req);
	}
}
