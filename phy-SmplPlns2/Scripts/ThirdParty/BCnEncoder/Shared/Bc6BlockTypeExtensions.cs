namespace BCnEncoder.Shared
{
	internal static class Bc6BlockTypeExtensions
	{
		public static bool HasSubsets(this Bc6BlockType Type)
		{
			return Type switch
			{
				Bc6BlockType.Type3 => false, 
				Bc6BlockType.Type7 => false, 
				Bc6BlockType.Type11 => false, 
				Bc6BlockType.Type15 => false, 
				_ => true, 
			};
		}

		public static bool HasTransformedEndpoints(this Bc6BlockType Type)
		{
			return Type switch
			{
				Bc6BlockType.Type3 => false, 
				Bc6BlockType.Type30 => false, 
				_ => true, 
			};
		}

		public static int EndpointBits(this Bc6BlockType Type)
		{
			return Type switch
			{
				Bc6BlockType.Type0 => 10, 
				Bc6BlockType.Type1 => 7, 
				Bc6BlockType.Type2 => 11, 
				Bc6BlockType.Type6 => 11, 
				Bc6BlockType.Type10 => 11, 
				Bc6BlockType.Type14 => 9, 
				Bc6BlockType.Type18 => 8, 
				Bc6BlockType.Type22 => 8, 
				Bc6BlockType.Type26 => 8, 
				Bc6BlockType.Type30 => 6, 
				Bc6BlockType.Type3 => 10, 
				Bc6BlockType.Type7 => 11, 
				Bc6BlockType.Type11 => 12, 
				Bc6BlockType.Type15 => 16, 
				_ => 0, 
			};
		}

		public static (int, int, int) DeltaBits(this Bc6BlockType Type)
		{
			return Type switch
			{
				Bc6BlockType.Type0 => (5, 5, 5), 
				Bc6BlockType.Type1 => (6, 6, 6), 
				Bc6BlockType.Type2 => (5, 4, 4), 
				Bc6BlockType.Type6 => (4, 5, 4), 
				Bc6BlockType.Type10 => (4, 4, 5), 
				Bc6BlockType.Type14 => (5, 5, 5), 
				Bc6BlockType.Type18 => (6, 5, 5), 
				Bc6BlockType.Type22 => (5, 6, 5), 
				Bc6BlockType.Type26 => (5, 5, 6), 
				Bc6BlockType.Type30 => (0, 0, 0), 
				Bc6BlockType.Type3 => (0, 0, 0), 
				Bc6BlockType.Type7 => (9, 9, 9), 
				Bc6BlockType.Type11 => (8, 8, 8), 
				Bc6BlockType.Type15 => (4, 4, 4), 
				_ => (0, 0, 0), 
			};
		}
	}
}
