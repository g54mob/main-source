namespace haxe.lang
{
	public sealed class FieldHashConflict
	{
		public readonly int hash;

		public readonly string name;

		public object value;

		public FieldHashConflict next;

		public FieldHashConflict(int hash, string name, object value, FieldHashConflict next)
		{
		}
	}
}
