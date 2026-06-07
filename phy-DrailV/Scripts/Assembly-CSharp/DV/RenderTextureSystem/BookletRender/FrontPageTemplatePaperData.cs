using System.Collections.Generic;
using DV.Booklets;
using DV.ThingTypes;
using UnityEngine;

namespace DV.RenderTextureSystem.BookletRender
{
	public class FrontPageTemplatePaperData : TemplatePaperData
	{
		public string jobType;

		public string jobSubtype;

		public string jobId;

		public string jobDescription;

		public JobLicenses requiredLicenses;

		public List<CargoType> distinctCargoTypes;

		public List<CargoType> cargoTypePerCar;

		public string singleStationName;

		public string singleStationType;

		public Color singleStationBgColor;

		public string startStationName;

		public string startStationType;

		public Color startStationBgColor;

		public string endStationName;

		public string endStationType;

		public Color endStationBgColor;

		public List<Car_data> cars;

		public string trainLength;

		public string trainMass;

		public string trainValue;

		public string timeBonus;

		public string payment;

		public string pageNumber;

		public string totalPages;

		public Color jobTypeColor;

		public FrontPageTemplatePaperData(string jobType, string jobSubtype, string jobId, Color jobTypeColor, string jobDescription, JobLicenses requiredLicenses, List<CargoType> distinctCargoTypes, List<CargoType> cargoTypePerCar, string singleStationName, string singleStationType, Color singleStationBgColor, string startStationName, string startStationType, Color startStationBgColor, string endStationName, string endStationType, Color endStationBgColor, List<Car_data> cars, string trainLength, string trainMass, string trainValue, string timeBonus, string payment, string pageNumber, string totalPages)
		{
			this.jobType = jobType;
			this.jobSubtype = jobSubtype;
			this.jobId = jobId;
			this.jobTypeColor = jobTypeColor;
			this.jobDescription = jobDescription;
			this.requiredLicenses = requiredLicenses;
			this.distinctCargoTypes = distinctCargoTypes;
			this.cargoTypePerCar = cargoTypePerCar;
			this.singleStationName = singleStationName;
			this.singleStationType = singleStationType;
			this.singleStationBgColor = singleStationBgColor;
			this.startStationName = startStationName;
			this.startStationType = startStationType;
			this.startStationBgColor = startStationBgColor;
			this.endStationName = endStationName;
			this.endStationType = endStationType;
			this.endStationBgColor = endStationBgColor;
			this.cars = cars;
			this.trainLength = trainLength;
			this.trainMass = trainMass;
			this.trainValue = trainValue;
			this.timeBonus = timeBonus;
			this.payment = payment;
			this.pageNumber = pageNumber;
			this.totalPages = totalPages;
		}

		public override TemplatePaperType GetTemplatePaperType()
		{
			return TemplatePaperType.FrontPage;
		}
	}
}
