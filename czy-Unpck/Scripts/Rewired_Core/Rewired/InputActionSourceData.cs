namespace Rewired
{
	public struct InputActionSourceData
	{
		private Controller PQxjKAQNRjWZaZhctvIytmcdtVz;

		private ControllerMap FcwxSEAqxlQQhiIiSEyJjkwZaAa;

		private ActionElementMap KnjtwXumwyqOALcZdsihYdhUpLj;

		public Controller controller => PQxjKAQNRjWZaZhctvIytmcdtVz;

		public ControllerType controllerType => PQxjKAQNRjWZaZhctvIytmcdtVz.type;

		public ControllerMap controllerMap => FcwxSEAqxlQQhiIiSEyJjkwZaAa;

		public ActionElementMap actionElementMap => KnjtwXumwyqOALcZdsihYdhUpLj;

		public string elementIdentifierName => KnjtwXumwyqOALcZdsihYdhUpLj.elementIdentifierName;

		internal InputActionSourceData(Controller controller, ControllerMap controllerMap, ActionElementMap actionElementMap)
		{
			PQxjKAQNRjWZaZhctvIytmcdtVz = controller;
			FcwxSEAqxlQQhiIiSEyJjkwZaAa = controllerMap;
			KnjtwXumwyqOALcZdsihYdhUpLj = actionElementMap;
		}

		internal InputActionSourceData(pAbmAVcsPcjQUSUHsDdzTqGMLSN working)
		{
			PQxjKAQNRjWZaZhctvIytmcdtVz = working.djSTCtuXfIOUkuKgYhEAmyFNWUJ;
			FcwxSEAqxlQQhiIiSEyJjkwZaAa = working.PVhoJNjtQFhTjmwRsuJhvQWcbfU;
			KnjtwXumwyqOALcZdsihYdhUpLj = working.fGOEgVenBQpynjDLaZtrcIyVGYbg;
		}
	}
}
