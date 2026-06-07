using System;

namespace Assets.Scripts.Design.UI
{
	public interface IAirfoilEditor
	{
		string Name { get; }

		event Action<string> OnAirfoilChanged;

		void LoadDefault();

		void SetVisible(bool visible);

		bool TryLoad(string airfoil);
	}
}
