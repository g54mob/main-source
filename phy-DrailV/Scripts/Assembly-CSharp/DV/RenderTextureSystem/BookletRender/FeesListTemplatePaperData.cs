using System;
using System.Collections.Generic;
using DV.ThingTypes;

namespace DV.RenderTextureSystem.BookletRender
{
	public class FeesListTemplatePaperData : TemplatePaperData
	{
		[Serializable]
		public class FeeListElement
		{
			public string feeType;

			public string carId;

			public string elementTypeTitle;

			public TrainCarType carType;

			public CargoType cargoType;

			public ResourceType resourceType;

			public string amount1;

			public string amount2;

			public string pricePerUnit;

			public string totalElementPrice;

			public FeeListElement(string feeType, string carId, string elementTypeTitle, TrainCarType carType, CargoType cargoType, ResourceType resourceType, string amount1, string amount2, string pricePerUnit, string totalElementPrice)
			{
				this.feeType = feeType;
				this.carId = carId;
				this.elementTypeTitle = elementTypeTitle;
				this.carType = carType;
				this.cargoType = cargoType;
				this.resourceType = resourceType;
				this.amount1 = amount1;
				this.amount2 = amount2;
				this.pricePerUnit = pricePerUnit;
				this.totalElementPrice = totalElementPrice;
			}
		}

		public const int NUMBER_OF_FEE_ELEMENTS_PER_PAGE = 4;

		public string feesId;

		public string feeTypeTitle;

		public List<FeeListElement> feesElements;

		public string pageNumber;

		public string totalPages;

		public FeesListTemplatePaperData(string feesId, string feeTypeTitle, List<FeeListElement> feesElements, string pageNumber, string totalPages)
		{
			this.feesId = feesId;
			this.feeTypeTitle = feeTypeTitle;
			this.feesElements = feesElements;
			this.pageNumber = pageNumber;
			this.totalPages = totalPages;
		}

		public override TemplatePaperType GetTemplatePaperType()
		{
			return TemplatePaperType.FeesList;
		}
	}
}
