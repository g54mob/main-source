using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Ui.XmlLayoutExtensions
{
	public class RectTransformTagHandler : ElementTagHandler
	{
		public override bool isCustomElement => true;

		public override string prefabPath => "Ui/Prefabs/XmlLayout/RectTransform";

		public override MonoBehaviour primaryComponent => null;
	}
}
