using UnityEngine;

namespace ModApi.Craft.Parts
{
	public interface IPartGroupScript
	{
		public delegate void PartGroupDelegate(IPartGroupScript craftScript);

		IBodyScript BodyScript { get; }

		PartGroupData Data { get; }

		GameObject GameObject { get; }

		int Id { get; }

		Material Material { get; }

		Material MaterialTransparency { get; }

		IRendererMaterialMap PartGroupRenderer { get; }

		event PartGroupDisconnectedHandler Disconnected;

		event PartGroupDelegate Initialized;

		MaterialPropertyBlock GetMaterialPropertyBlockForNonCombinedMesh(IRendererMaterialMap rendererMaterialMap);

		void OnBeingDisconnected(bool isExploding);

		void RemovePart(PartData part);
	}
}
