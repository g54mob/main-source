using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using Cpp2ILInjected;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service;

public class GZipSaveDataCompressor : ISaveDataCompressor
{
	public unsafe string Compress(string input)
	{
		//IL_00c8: Expected I, but got O
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected O, but got Unknown
		//IL_00fd: Expected O, but got Ref
		Encoding uTF = Encoding.UTF8;
		byte[] bytes = uTF.GetBytes(input);
		MemoryStream memoryStream = new MemoryStream();
		Stream stream = default(Stream);
		GZipStream gZipStream = new GZipStream(stream, CompressionMode.Compress);
		if (bytes != null)
		{
			GZipStream gZipStream2 = default(GZipStream);
			if (gZipStream2 != null)
			{
				gZipStream2.Write(bytes, 0, bytes.Length);
				if (gZipStream2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				if (stream != null)
				{
					nint num = (nint)stream;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v262 @ rdx_v12 (Il2CppClass<System.ArgumentNullException>)+3F8] (should have been resolved before IL gen)");
					object obj = default(object);
					if (obj != null)
					{
						object obj2 = obj + 32;
						object obj3 = default(object);
						string result = Convert.ToBase64String((ReadOnlySpan<byte>)(&obj3));
						if (stream != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
						}
						return result;
					}
					ArgumentNullException ex = new ArgumentNullException("inArray");
					throw ex;
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	public unsafe string Decompress(string input)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected I, but got Unknown
		//IL_00f6: Expected I, but got O
		//IL_0125: Expected I, but got O
		if (input != null)
		{
			char* inputPtr = (char*)(nint)(input + 20);
			byte[] buffer = Convert.FromBase64CharPtr(inputPtr, input._stringLength);
			MemoryStream memoryStream = new MemoryStream(buffer, writable: true);
			MemoryStream memoryStream2 = new MemoryStream();
			Stream stream = default(Stream);
			GZipStream gZipStream = new GZipStream(stream, CompressionMode.Decompress);
			Stream stream2 = default(Stream);
			if (stream2 != null)
			{
				Stream stream3 = default(Stream);
				stream2.CopyTo(stream3);
				if (stream2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				Encoding uTF = Encoding.UTF8;
				if (stream3 != null)
				{
					nint num = (nint)stream3;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v310 @ rdx_v12 (Il2CppClass<System.ArgumentNullException>)+3F8] (should have been resolved before IL gen)");
					if (uTF != null)
					{
						nint num2 = (nint)uTF;
						byte[] bytes = default(byte[]);
						string result = uTF.GetString(bytes);
						if (stream3 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
						}
						if (stream != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
						}
						return result;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		ArgumentNullException ex = new ArgumentNullException("s");
		throw ex;
	}
}
