using System.Collections.Generic;
using UnityEngine;

namespace DV.RenderTextureSystem.BookletRender
{
	public abstract class TemplatePaper : MonoBehaviour
	{
		public const string CARGO_ICON_GO_NAME = "[cargo icon]";

		protected List<GameObject> dynamicallyCreatedObjects = new List<GameObject>();

		public abstract void FillInData();

		public abstract void CleanUp();
	}
}
