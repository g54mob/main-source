using KitchenData;
using TMPro;
using UnityEngine;

namespace Kitchen.Modules
{
	public class DecorationBonusElement : Element
	{
		public MeshRenderer Background;

		public TextMeshPro Label;

		public TextMeshPro Requirements;

		public Color Active;

		public Color Inactive;

		private static readonly int Highlight = Shader.PropertyToID("_Highlight");

		public override Bounds BoundingBox => new Bounds(base.transform.localPosition, new Vector3(base.transform.localScale.x * Background.transform.localScale.x, base.transform.localScale.y * Background.transform.localScale.y, 0f));

		public void Set(string label, DecorationType decor, int current, int target)
		{
			bool flag = current >= target;
			Label.text = label;
			string text = (flag ? ("<sprite name=\"ready\" tint=1> " + decor.Icon()) : $"{current}/{target} {decor.Icon()}");
			Requirements.text = text;
			Requirements.color = (flag ? Active : Inactive);
			Label.color = (flag ? Color.white : Inactive);
			if (Background != null)
			{
				base.MemoryManagerHandle.Register(Background.material).SetColor(Highlight, flag ? Active : Inactive);
			}
		}
	}
}
