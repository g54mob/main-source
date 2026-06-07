using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public interface ITransformToolGizmo
	{
		bool Highlighted { get; set; }

		bool Inactive { get; set; }

		bool Selected { get; set; }

		Transform Transform { get; }
	}
}
