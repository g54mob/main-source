using System.Text;
using Febucci.Numbers;

namespace Febucci.Parsing.Regions
{
	public struct TagRange
	{
		public Vector2Int indexes;

		public RegionParameters parameters;

		public TagRange(Vector2Int indexes, RegionParameters parameters)
		{
			this.indexes = indexes;
			this.parameters = parameters;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("- indexes: ");
			stringBuilder.Append(indexes);
			if (parameters == null)
			{
				stringBuilder.Append("\n- Parameters is null");
			}
			else
			{
				stringBuilder.Append("\n- " + parameters.ToString());
			}
			return stringBuilder.ToString();
		}
	}
}
