using System;

namespace Assets.Scripts.XR.UI.Layout
{
	public interface IQueryInputAction : IDisposable
	{
		event Action BindingsChanged;

		string GetActionName(string inputBindingPath, HandScriptBase hand);
	}
}
