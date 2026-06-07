using UnityEngine;

namespace ModApi.Craft.Program.Craft
{
	public interface IGaugeWidget
	{
		Vector3 BackgroundColor { get; set; }

		Vector3 FillColor { get; set; }

		string Text { get; set; }

		Vector3 TextColor { get; set; }

		float Value { get; set; }
	}
}
