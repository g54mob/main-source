using ModApi.Ui.Inspector;

namespace ModApi.Craft.Program.Craft
{
	public interface ILabelWidget
	{
		bool AutoSize { get; set; }

		float FontSize { get; set; }

		string Text { get; set; }

		ElementAlignment TextAlignment { get; set; }
	}
}
