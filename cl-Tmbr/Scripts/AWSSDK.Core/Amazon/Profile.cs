using System.Text;

namespace Amazon
{
	public class Profile
	{
		private string location;

		public string Name { get; set; }

		public string Location
		{
			get
			{
				return location;
			}
			set
			{
				location = value;
			}
		}

		public Profile(string name)
		{
			Name = name;
		}

		public Profile(string name, string location)
		{
			Name = name;
			Location = location;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("Profile Name: " + Name);
			stringBuilder.AppendLine("Location: " + Location);
			return stringBuilder.ToString();
		}
	}
}
