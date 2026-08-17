using System;
using System.Security.Cryptography;
using System.Text;
using Cpp2ILInjected;

namespace VampireSurvivors.App.Tools;

public static class EncryptionHelper
{
	public unsafe static string Encrypt(string plainText, string key, string iv)
	{
		//IL_0127: Expected O, but got Ref
		AesCryptoServiceProvider aesCryptoServiceProvider = (AesCryptoServiceProvider)new Aes();
		((Aes)aesCryptoServiceProvider)._002Ector();
		((SymmetricAlgorithm)aesCryptoServiceProvider).FeedbackSizeValue = 8;
		aesCryptoServiceProvider.BlockSize = 128;
		aesCryptoServiceProvider.KeySize = 256;
		Encoding aSCII = Encoding.ASCII;
		byte[] bytes = aSCII.GetBytes(key);
		aesCryptoServiceProvider.Key = bytes;
		Encoding aSCII2 = Encoding.ASCII;
		byte[] bytes2 = aSCII2.GetBytes(iv);
		aesCryptoServiceProvider.IV = bytes2;
		aesCryptoServiceProvider.Mode = CipherMode.CBC;
		aesCryptoServiceProvider.Padding = PaddingMode.PKCS7;
		Encoding aSCII3 = Encoding.ASCII;
		byte[] bytes3 = aSCII3.GetBytes(plainText);
		byte[] key2 = aesCryptoServiceProvider.Key;
		byte[] iV = aesCryptoServiceProvider.IV;
		ICryptoTransform cryptoTransform = aesCryptoServiceProvider.CreateEncryptor(key2, iV);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180995CB0");
		object obj = default(object);
		object obj2 = default(object);
		if (obj != null)
		{
			return Convert.ToBase64String((ReadOnlySpan<byte>)(&obj2));
		}
		ArgumentNullException ex = new ArgumentNullException("inArray");
		ex._002Ector("inArray");
		throw ex;
	}

	public unsafe static string DesDecrypt(string encryptedString, string key, string iv)
	{
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected I, but got Unknown
		//IL_00e7: Expected I, but got O
		//IL_0119: Expected I, but got O
		//IL_0129: Expected O, but got I
		//IL_0139: Expected O, but got I
		AesCryptoServiceProvider aesCryptoServiceProvider = (AesCryptoServiceProvider)new Aes();
		((Aes)aesCryptoServiceProvider)._002Ector();
		((SymmetricAlgorithm)aesCryptoServiceProvider).FeedbackSizeValue = 8;
		aesCryptoServiceProvider.BlockSize = 128;
		aesCryptoServiceProvider.KeySize = 256;
		Encoding aSCII = Encoding.ASCII;
		byte[] bytes = aSCII.GetBytes(key);
		aesCryptoServiceProvider.Key = bytes;
		Encoding aSCII2 = Encoding.ASCII;
		byte[] bytes2 = aSCII2.GetBytes(iv);
		aesCryptoServiceProvider.IV = bytes2;
		aesCryptoServiceProvider.Mode = CipherMode.CBC;
		aesCryptoServiceProvider.Padding = PaddingMode.PKCS7;
		ArgumentNullException ex = default(ArgumentNullException);
		if (encryptedString != null)
		{
			char* inputPtr = (char*)(nint)(encryptedString + 20);
			byte[] array = Convert.FromBase64CharPtr(inputPtr, encryptedString._stringLength);
			nint num = (nint)aesCryptoServiceProvider;
			ICryptoTransform cryptoTransform = aesCryptoServiceProvider.CreateDecryptor();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180995CB0");
			Encoding aSCII3 = Encoding.ASCII;
			nint num2 = (nint)aSCII3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ r8_v17 (Il2CppClass<System.Text.Encoding>)+368]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ r8_v17 (Il2CppClass<System.Text.Encoding>)+370]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v312 @ r9_v8 (should have been resolved before IL gen)");
		}
		else
		{
			ex = new ArgumentNullException("s");
		}
		ex._002Ector("s");
		throw ex;
	}
}
