using System;
using System.IO;
using System.Security.Cryptography;
using Cpp2ILInjected;

public static class SimpleEncryptor
{
	private static readonly byte[] Key = new byte[32]
	{
		217, 64, 132, 13, 90, 231, 199, 144, 123, 9,
		36, 55, 188, 12, 91, 68, 170, 247, 14, 39,
		62, 18, 208, 251, 77, 162, 184, 199, 103, 204,
		145, 29
	};

	private static readonly byte[] IV = new byte[16]
	{
		55, 134, 78, 241, 92, 36, 188, 10, 203, 198,
		14, 57, 120, 239, 31, 6
	};

	public static string Encrypt(string plainText)
	{
		//IL_00df: Expected I, but got O
		//IL_00ec: Expected I4, but got O
		//IL_0149: Expected I, but got O
		Aes aes = Aes.Create();
		object obj = default(object);
		if (obj != null)
		{
			object obj2 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v101 @ rax_v8+1F8] (should have been resolved before IL gen)");
			object obj3 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v195 @ r9_v3+1D8] (should have been resolved before IL gen)");
			object obj4 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v245 @ rax_v16+1E8] (should have been resolved before IL gen)");
			object obj5 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v372 @ r8_v7+1C8] (should have been resolved before IL gen)");
			object obj6 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v333 @ r10_v5+288] (should have been resolved before IL gen)");
			MemoryStream memoryStream = new MemoryStream();
			Stream stream = default(Stream);
			ICryptoTransform cryptoTransform = default(ICryptoTransform);
			CryptoStream cryptoStream = new CryptoStream(stream, cryptoTransform, CryptoStreamMode.Write);
			CryptoStream cryptoStream2 = default(CryptoStream);
			StreamWriter streamWriter = new StreamWriter(cryptoStream2);
			CryptoStream cryptoStream3 = default(CryptoStream);
			if (cryptoStream3 != null)
			{
				nint num = (nint)cryptoStream3;
				cryptoStream3.WriteTimeout = (int)plainText;
				if (cryptoStream3 != null)
				{
					bool canWrite = cryptoStream3.CanWrite;
					if (cryptoStream2 != null)
					{
						cryptoStream2.FlushFinalBlock();
						nint num2 = (nint)stream;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v510 @ rax_v49 (Il2CppClass<System.Security.Cryptography.CryptoStream>)+3B8] (should have been resolved before IL gen)");
						byte[] inArray = default(byte[]);
						string result = Convert.ToBase64String(inArray);
						if (cryptoStream3 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
						}
						if (cryptoStream2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
						}
						if (stream != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
						}
						if (cryptoTransform != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
						}
						if (obj != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
						}
						return result;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		return (string)(object)new NullReferenceException();
	}

	public static string Decrypt(string encryptedText)
	{
		byte[] buffer = Convert.FromBase64String(encryptedText);
		Aes aes = Aes.Create();
		object obj = default(object);
		if (obj != null)
		{
			object obj2 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v119 @ rax_v10+1F8] (should have been resolved before IL gen)");
			object obj3 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v211 @ r9_v3+1D8] (should have been resolved before IL gen)");
			object obj4 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v261 @ rax_v18+1E8] (should have been resolved before IL gen)");
			object obj5 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v378 @ r8_v7+1C8] (should have been resolved before IL gen)");
			object obj6 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v341 @ r10_v5+2A8] (should have been resolved before IL gen)");
			MemoryStream memoryStream = new MemoryStream(buffer);
			Stream stream = default(Stream);
			ICryptoTransform cryptoTransform = default(ICryptoTransform);
			CryptoStream cryptoStream = new CryptoStream(stream, cryptoTransform, CryptoStreamMode.Read);
			Stream stream2 = default(Stream);
			StreamReader streamReader = new StreamReader(stream2);
			object obj7 = default(object);
			if (obj7 != null)
			{
				object obj8 = obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v429 @ rax_v40+208] (should have been resolved before IL gen)");
				if (obj7 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
				}
				if (stream2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
				}
				if (stream != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
				}
				if (cryptoTransform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
				}
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
				}
				string result = default(string);
				return result;
			}
			throw new NullReferenceException();
		}
		return (string)(object)new NullReferenceException();
	}
}
