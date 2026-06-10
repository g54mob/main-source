using System.Collections.Generic;
using NSMedieval.UI;

namespace NSMedieval.Model
{
	public class InfoPanelData
	{
		public InfoPanelDataType Type { get; }

		public InfoPanelHeader Header { get; }

		public InfoPanelBody Body { get; }

		public InfoPanelWorkerBody WorkerBody { get; }

		public InfoPanelFooter Footer { get; }

		public List<SelectionExtraView> ExtraPanelViews { get; }

		public InfoPanelEnemyBody EnemyBody { get; }

		public InfoPanelAnimalBody AnimalBody { get; }

		public InfoPanelData(InfoPanelDataType type, InfoPanelHeader header, InfoPanelBody body, InfoPanelFooter footer, SelectionExtraView extraPanelView = null)
		{
			Type = type;
			Header = header;
			Body = body;
			Footer = footer;
			ExtraPanelViews = new List<SelectionExtraView> { extraPanelView };
		}

		public InfoPanelData(InfoPanelDataType type, InfoPanelHeader header, InfoPanelBody body, InfoPanelFooter footer, List<SelectionExtraView> extraPanelViews)
		{
			Type = type;
			Header = header;
			Body = body;
			Footer = footer;
			ExtraPanelViews = extraPanelViews;
		}

		public InfoPanelData(InfoPanelHeader header, InfoPanelWorkerBody body, InfoPanelFooter footer, SelectionExtraView extraPanelView = null)
		{
			Type = InfoPanelDataType.Worker;
			Header = header;
			WorkerBody = body;
			Footer = footer;
			ExtraPanelViews = new List<SelectionExtraView> { extraPanelView };
		}

		public InfoPanelData(InfoPanelHeader header, InfoPanelEnemyBody body, InfoPanelFooter footer, SelectionExtraView extraPanelView = null)
		{
			Type = InfoPanelDataType.Enemy;
			Header = header;
			EnemyBody = body;
			Footer = footer;
			ExtraPanelViews = new List<SelectionExtraView> { extraPanelView };
		}

		public InfoPanelData(InfoPanelHeader header, InfoPanelAnimalBody body, InfoPanelFooter footer, SelectionExtraView extraPanelView = null)
		{
			Type = InfoPanelDataType.Animal;
			Header = header;
			AnimalBody = body;
			Footer = footer;
			ExtraPanelViews = new List<SelectionExtraView> { extraPanelView };
		}

		public void AppendExtraPanelView(SelectionExtraView extraPanelView)
		{
			ExtraPanelViews?.Add(extraPanelView);
		}
	}
}
