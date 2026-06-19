using System.Collections;
using Loxodon.Framework.Commands;
using Loxodon.Framework.Execution;
using Loxodon.Framework.ViewModels;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class ButtonGroupViewModel : ViewModelBase
	{
		private string text;

		private Color color;

		private readonly SimpleCommand<string> click;

		private readonly SimpleCommand<Color> clickColor;

		public string Text
		{
			get
			{
				return text;
			}
			set
			{
				Set(ref text, value, "Text");
			}
		}

		public Color Color
		{
			get
			{
				return color;
			}
			set
			{
				Set(ref color, value, "Color");
			}
		}

		public ICommand Click => click;

		public ICommand ClickColor => clickColor;

		public ButtonGroupViewModel()
		{
			click = new SimpleCommand<string>(OnClick);
			clickColor = new SimpleCommand<Color>(OnClickColor);
		}

		public void OnClick(string buttonText)
		{
			Executors.RunOnCoroutineNoReturn(DoClick(buttonText));
		}

		private void OnClickColor(Color color)
		{
			Color = color;
		}

		private IEnumerator DoClick(string buttonText)
		{
			click.Enabled = false;
			Text = $"Click Button:{buttonText}.Restore button status after one second";
			Debug.LogFormat("Click Button:{0}", buttonText);
			yield return new WaitForSeconds(1f);
			click.Enabled = true;
		}

		public void ChangeColor()
		{
			Color = Random.ColorHSV();
			Debug.Log("Changing color to " + Color.ToString());
		}
	}
}
