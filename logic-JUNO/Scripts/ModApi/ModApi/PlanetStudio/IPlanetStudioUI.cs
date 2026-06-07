using System;
using ModApi.Ui;
using UnityEngine;

namespace ModApi.PlanetStudio
{
	public interface IPlanetStudioUI
	{
		PlanetStudioEditMode EditMode { get; set; }

		IEquirectangularMapView EquirectangularMapView { get; }

		bool IsLoading { get; set; }

		IPlanetStudio PlanetStudio { get; }

		IFlyout SelectedFlyout { get; set; }

		RectTransform Transform { get; }

		bool Visible { get; set; }

		event EventHandler<EventArgs> EditModeChanged;

		IListView CreateListView(IListViewModel viewModel);

		void CreateUndoStep(string ignoreKey = null, string description = null);

		void ShowMessage(string message, float time = 7f);
	}
}
