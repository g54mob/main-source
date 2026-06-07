namespace haxe.lang
{
	public sealed class FieldLookup
	{
		protected static int[] fieldIds;

		protected static string[] fields;

		protected static int length;

		static FieldLookup()
		{
		}

		public static void addFields(int[] nids, string[] nfields)
		{
		}

		public static int doHash(string s)
		{
			return 0;
		}

		public static string lookupHash(int key)
		{
			return null;
		}

		public static int hash(string s)
		{
			return 0;
		}

		public static int findHash(int hash, int[] hashs, int length)
		{
			return 0;
		}

		public static void removeInt(int[] a, int length, int pos)
		{
		}

		public static void removeFloat(double[] a, int length, int pos)
		{
		}

		public static void removeDynamic(object[] a, int length, int pos)
		{
		}

		public static int[] insertInt(int[] a, int length, int pos, int x)
		{
			return null;
		}

		public static double[] insertFloat(double[] a, int length, int pos, double x)
		{
			return null;
		}

		public static object[] insertDynamic(object[] a, int length, int pos, object x)
		{
			return null;
		}

		public static string[] insertString(string[] a, int length, int pos, string x)
		{
			return null;
		}

		public static FieldHashConflict getHashConflict(FieldHashConflict head, int hash, string name)
		{
			return null;
		}

		public static void setHashConflict(ref FieldHashConflict head, int hash, string name, object value)
		{
		}

		public static bool deleteHashConflict(ref FieldHashConflict head, int hash, string name)
		{
			return false;
		}

		public static void addHashConflictNames(FieldHashConflict head, Array arr)
		{
		}
	}
}
