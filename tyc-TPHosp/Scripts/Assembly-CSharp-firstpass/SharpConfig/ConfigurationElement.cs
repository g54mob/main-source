using System;

namespace SharpConfig
{
	public abstract class ConfigurationElement
	{
		public string Name { get; private set; }

		public string Comment { get; set; }

		public string PreComment { get; set; }

		internal ConfigurationElement(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException("name");
			}
			Name = name;
		}

		public override string ToString()
		{
			return ToString(includeComments: false);
		}

		public string ToString(bool includeComments)
		{
			string stringExpression = GetStringExpression();
			if (includeComments)
			{
				if (Comment != null && PreComment != null)
				{
					return $"{GetFormattedPreComment()}{Environment.NewLine}{stringExpression} {GetFormattedComment()}";
				}
				if (Comment != null)
				{
					return $"{stringExpression} {GetFormattedComment()}";
				}
				if (PreComment != null)
				{
					return $"{GetFormattedPreComment()}{Environment.NewLine}{stringExpression}";
				}
			}
			return stringExpression;
		}

		private string GetFormattedComment()
		{
			string text = Comment;
			int num = Comment.IndexOfAny(Environment.NewLine.ToCharArray());
			if (num >= 0)
			{
				text = text.Substring(0, num);
			}
			return Configuration.PreferredCommentChar + " " + text;
		}

		private string GetFormattedPreComment()
		{
			string[] array = PreComment.Split(new string[2] { "\r\n", "\n" }, StringSplitOptions.None);
			return string.Join(Environment.NewLine, Array.ConvertAll(array, (string s) => Configuration.PreferredCommentChar + " " + s));
		}

		protected abstract string GetStringExpression();
	}
}
