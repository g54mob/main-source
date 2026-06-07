using System.Collections.Generic;
using ManagementScripts;
using SettingScripts;
using UIScripts.SettingHandles;
using UnityEngine;
using UnityEngine.Serialization;
using Utility;

namespace UIScripts.UIReferences
{
	public class GraphsPanel : UIPanel
	{
		public GameObject historicGraphPage;

		public GameObject genesGraphPage;

		[FormerlySerializedAs("graph")]
		public DataStreamLinesGraph historicGraph;

		public BarGraph genesGraph;

		public RealDropdown dataDropdown;

		public TogglesDropdown curvesDropdown;

		public RealDropdown genesDropdown;

		public LogLikeTimeSpanSlider genesTimeSlider;

		public int loggedGenes;

		private List<IDataPointStream> streams;

		private int activeGraph;

		private void Start()
		{
			streams = DataLogger.Instance.parallelDataStreams;
			foreach (IDataPointStream stream in streams)
			{
				dataDropdown.AddOption(new DropdownItemData(stream.groupTitle, stream.groupDesc));
			}
			dataDropdown.onValueChanged.AddListener(ChangeSelectedHistoricalData);
			dataDropdown.value = 0;
			curvesDropdown.onValueChanged.AddListener(historicGraph.UpdateSelectedCurves);
			foreach (GeneSetting item in BibiteEditorSettings.geneSettingsOrdered)
			{
				genesDropdown.AddOption(new DropdownItemData(item.Name, item.HelperText));
			}
			genesDropdown.value = 16;
			genesDropdown.onValueChanged.AddListener(genesGraph.UpdateSelectedData);
			genesTimeSlider.SetConfig(DataLogger.SerialHeavyConfig);
			genesTimeSlider.value = -1;
			genesTimeSlider.onTimeIndexChange.AddListener(ChangedGenesGraphTime);
			OpenGeneAnalysis();
			OpenHistoricalGraph();
		}

		private void ChangeSelectedHistoricalData(int i)
		{
			IDataPointStream dataPointStream = streams[i];
			DataStreamDescription[] streamsDescriptions = dataPointStream.GetStreamsDescriptions();
			historicGraph.SetDataStream(dataPointStream);
			curvesDropdown.ClearOptions();
			DataStreamDescription[] array = streamsDescriptions;
			foreach (DataStreamDescription dataStreamDescription in array)
			{
				curvesDropdown.AddOption(new DropdownItemData(dataStreamDescription.label, dataStreamDescription.description, dataStreamDescription.state));
			}
			curvesDropdown.UpdateHandles();
		}

		private void ChangedGenesGraphTime(int val)
		{
			genesGraph.UpdateTime(val);
		}

		public override void OpenPanel()
		{
			base.OpenPanel();
			TimeController.Instance.TogglePauseGame("GraphsPanel");
			loggedGenes = DataLogger.Instance.genesStreamGroup.data.nData;
			genesTimeSlider.SetMinMax(-1, loggedGenes - 1);
			if (activeGraph == 0)
			{
				OpenHistoricalGraph();
			}
			if (activeGraph == 1)
			{
				OpenGeneAnalysis();
			}
		}

		public override void ClosePanel()
		{
			base.ClosePanel();
			TimeController.Instance.TogglePauseGame("GraphsPanel", isUnpause: true);
		}

		public void OpenHistoricalGraph()
		{
			historicGraphPage.SetActive(value: true);
			genesGraphPage.SetActive(value: false);
			activeGraph = 0;
		}

		public void OpenGeneAnalysis()
		{
			genesGraphPage.SetActive(value: true);
			historicGraphPage.SetActive(value: false);
			activeGraph = 1;
		}
	}
}
