using UnityEngine;

namespace MK.Toon
{
	public abstract class Property<T>
	{
		protected string[] _keywords;

		protected Uniform _uniform;

		public Uniform uniform => null;

		public Property(Uniform uniform, params string[] keywords)
		{
		}

		public abstract T GetValue(Material material);

		public abstract void SetValue(Material material, T value);

		protected void SetKeyword(Material material, bool b, int keywordIndex)
		{
		}

		private void CleanKeywords(Material material)
		{
		}
	}
	public abstract class Property<T, U> : Property<T>
	{
		public Property(Uniform uniform, params string[] keywords)
			: base((Uniform)null, (string[])null)
		{
		}

		public abstract void SetValue(Material material, T valueM, U valueS);
	}
}
