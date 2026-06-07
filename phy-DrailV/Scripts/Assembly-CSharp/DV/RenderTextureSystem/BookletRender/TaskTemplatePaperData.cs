using System.Collections.Generic;
using DV.Booklets;
using DV.ThingTypes;
using UnityEngine;

namespace DV.RenderTextureSystem.BookletRender
{
	public class TaskTemplatePaperData : TemplatePaperData
	{
		public string stepNum;

		public string taskType;

		public string taskDescription;

		public string yardId;

		public Color yardColor;

		public string trackId;

		public Color trackColor;

		public string stationName;

		public string stationType;

		public Color stationColor;

		public List<Car_data> cars;

		public List<CargoType> cargoTypePerCar;

		public string pageNumber;

		public string totalPages;

		public TaskTemplatePaperData(string stepNum, string taskType, string taskDescription, string yardId, Color yardColor, string trackId, Color trackColor, string stationName, string stationType, Color stationColor, List<Car_data> cars, List<CargoType> cargoTypePerCar, string pageNumber, string totalPages)
		{
			this.stepNum = stepNum;
			this.taskType = taskType;
			this.taskDescription = taskDescription;
			this.yardId = yardId;
			this.yardColor = yardColor;
			this.trackId = trackId;
			this.trackColor = trackColor;
			this.stationName = stationName;
			this.stationType = stationType;
			this.stationColor = stationColor;
			this.cars = cars;
			this.cargoTypePerCar = cargoTypePerCar;
			this.pageNumber = pageNumber;
			this.totalPages = totalPages;
		}

		public override TemplatePaperType GetTemplatePaperType()
		{
			return TemplatePaperType.TaskPage;
		}
	}
}
