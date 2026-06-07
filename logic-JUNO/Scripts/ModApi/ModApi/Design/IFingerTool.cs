using UnityEngine;

namespace ModApi.Design
{
	public interface IFingerTool
	{
		bool Enabled { get; set; }

		bool PartButtonsEnabled { get; }

		Vector2 Position { get; set; }
	}
}
