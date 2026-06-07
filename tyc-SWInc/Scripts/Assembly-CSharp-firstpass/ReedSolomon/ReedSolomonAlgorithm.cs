using System;

namespace ReedSolomon
{
	public static class ReedSolomonAlgorithm
	{
		public static byte[] Encode(byte[] message, int eccCount, ErrorCorrectionCodeType eccType)
		{
			GenericGF field;
			switch (eccType)
			{
			case ErrorCorrectionCodeType.QRCode:
				field = GenericGF.QR_CODE_FIELD_256;
				break;
			case ErrorCorrectionCodeType.DataMatrix:
				field = GenericGF.DATA_MATRIX_FIELD_256;
				break;
			default:
				throw new ArgumentException("Invalid 'eccType' argument.", "eccType");
			}
			return new ReedSolomonEncoder(field).EncodeEx(message, eccCount);
		}

		public static byte[] Encode(byte[] message, int eccCount)
		{
			return Encode(message, eccCount, ErrorCorrectionCodeType.DataMatrix);
		}

		public static byte[] Decode(byte[] message, byte[] ecc, ErrorCorrectionCodeType eccType)
		{
			GenericGF field;
			switch (eccType)
			{
			case ErrorCorrectionCodeType.QRCode:
				field = GenericGF.QR_CODE_FIELD_256;
				break;
			case ErrorCorrectionCodeType.DataMatrix:
				field = GenericGF.DATA_MATRIX_FIELD_256;
				break;
			default:
				throw new ArgumentException("Invalid 'eccType' argument.", "eccType");
			}
			return new ReedSolomonDecoder(field).DecodeEx(message, ecc);
		}

		public static byte[] Decode(byte[] message, byte[] ecc)
		{
			return Decode(message, ecc, ErrorCorrectionCodeType.DataMatrix);
		}
	}
}
