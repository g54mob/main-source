using Factory;
using UnityEngine;

namespace Motorways.Views
{
	public interface IOnScreenTool
	{
		Rect InputBlockingRect { get; }

		void OnGUI(IScope scope);

		void Update();
	}
}
