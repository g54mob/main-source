using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public interface IMultipleHighlight
	{
		void GetMultipleHighlightGameObjects(List<Renderer> result);
	}
}
