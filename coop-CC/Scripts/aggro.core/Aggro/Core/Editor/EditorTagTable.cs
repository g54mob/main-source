namespace Aggro.Core.Editor
{
	public struct EditorTagTable
	{
		private string[] _tags;

		internal EditorTagTable(string[] tags)
		{
			_tags = tags;
		}

		public string GetTagLabel(int bit)
		{
			return _tags[bit];
		}
	}
}
