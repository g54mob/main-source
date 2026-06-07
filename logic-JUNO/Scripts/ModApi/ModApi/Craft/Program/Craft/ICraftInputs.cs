namespace ModApi.Craft.Program.Craft
{
	public interface ICraftInputs
	{
		float Brake { get; set; }

		float Pitch { get; set; }

		float Roll { get; set; }

		float Slider1 { get; set; }

		float Slider2 { get; set; }

		float Slider3 { get; set; }

		float Slider4 { get; set; }

		float Throttle { get; set; }

		float TranslateForward { get; set; }

		float TranslateRight { get; set; }

		float TranslateUp { get; set; }

		bool TranslationMode { get; set; }

		float Yaw { get; set; }
	}
}
