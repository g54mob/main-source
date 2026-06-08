using UnityEngine;

namespace Kitchen.NetworkSupport
{
	public struct LoggedEvent<T>
	{
		public string Tag;

		public Color Colour;

		public float Time;

		public T Event;

		public string Details;

		public string Printable;

		public LoggedEvent(string tag, Color col, float time, T evt, string detail)
		{
			Tag = tag;
			Colour = col;
			Time = time;
			Event = evt;
			Details = detail;
			ColorUtility.ToHtmlStringRGBA(Colour);
			string tag2 = Tag;
			if (Details == "")
			{
				Printable = $"[{Time:F2} {tag2}] {Event}";
				return;
			}
			Printable = $"[{Time:F2} {tag2}] {Event}: {Details}";
		}

		public override string ToString()
		{
			return Printable;
		}
	}
}
