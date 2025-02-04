namespace MediScoreCalculation
{
	public  class PatientRecord
	{
		public enum Medium :int
		{
			Air = 0,
			Oxygen = 2
		}
		public enum Consciousness : int
		{
			Alert = 0,
			CPUV = 1
		}

		private  int _respiration_rate;
		private float _temperature;
		private Medium _breathingmedium;
		private Consciousness _consciousness;
		private int _oxygensaturation;

		public Medium BreathingMedium
		{
			get { return _breathingmedium; }
			set { _breathingmedium = value; }
		}

		public Consciousness ConsciousnessLevel
		{
			get { return _consciousness; }
			set { _consciousness = value; }
		}

		public int Respiration_range
		{
			get { return _respiration_rate; }
			set { _respiration_rate = value; }
		}

		public int Oxygensaturation
		{
			get { return _oxygensaturation; }
			set { _oxygensaturation = value; }
		}
					
		public float Temperature
		{
			get { return _temperature; }
			set { _temperature = value; }
		}
		
	}
}