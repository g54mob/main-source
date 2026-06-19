using Pug.RP;
using UnityEngine;

namespace PugMod
{
	public interface IRendering
	{
		Vector3 RenderOffset { get; }

		PugCamera GameCamera { get; }

		PugCamera UICamera { get; }

		Material GetMaterial(string name);
	}
}
