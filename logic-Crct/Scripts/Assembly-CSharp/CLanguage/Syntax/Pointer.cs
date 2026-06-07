namespace CLanguage.Syntax
{
	public class Pointer
	{
		public TypeQualifiers TypeQualifiers { get; set; }

		public Pointer? NextPointer { get; set; }

		public Pointer(TypeQualifiers qual, Pointer p)
		{
		}

		public Pointer(TypeQualifiers qual)
		{
		}
	}
}
