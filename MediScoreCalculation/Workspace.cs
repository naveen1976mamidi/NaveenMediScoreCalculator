namespace MediScoreCalculation
{
	internal  class Workspace
	{

		Dictionary<int, PatientRecord> patientData = new Dictionary<int, PatientRecord>();
		public void CollectPatientReadings()
		{
			PatientRecord a_patientReading = new PatientRecord();
			a_patientReading.BreathingMedium = PatientRecord.Medium.Air;
			a_patientReading.ConsciousnessLevel = PatientRecord.Consciousness.Alert;
			a_patientReading.Respiration_range = 0;
			a_patientReading.Oxygensaturation = 95;
			a_patientReading.Temperature = 37.1F;


			PatientRecord b_patientReading = new PatientRecord();
			b_patientReading.BreathingMedium = PatientRecord.Medium.Oxygen;
			b_patientReading.ConsciousnessLevel = PatientRecord.Consciousness.Alert;
			b_patientReading.Respiration_range = 17;
			b_patientReading.Oxygensaturation = 95;
			b_patientReading.Temperature = 37.1F;


			PatientRecord c_patientReading = new PatientRecord();
			c_patientReading.BreathingMedium = PatientRecord.Medium.Oxygen;
			c_patientReading.ConsciousnessLevel = PatientRecord.Consciousness.CPUV;
			c_patientReading.Respiration_range = 23;
			c_patientReading.Oxygensaturation = 88;
			c_patientReading.Temperature = 38.5F;


			PatientRecord d_patientReading = new PatientRecord();
			d_patientReading.BreathingMedium = PatientRecord.Medium.Air;
			d_patientReading.ConsciousnessLevel = PatientRecord.Consciousness.Alert;
			d_patientReading.Respiration_range = 50;
			d_patientReading.Oxygensaturation = 100;
			d_patientReading.Temperature = 39.0F;


			patientData.Add(11111, a_patientReading);
			patientData.Add(11112, b_patientReading);
			patientData.Add(11113, c_patientReading);
			patientData.Add(11114, d_patientReading);
		}

		public void CalculatePatientMediScores()
		{

			Dictionary<int, int> objScore = new Dictionary<int, int>();

			foreach (var pData in patientData)
			{
				PatientRecord obj = pData.Value;
				int score = MediScoreCalculator.Calculate((int)obj.BreathingMedium, (int)obj.ConsciousnessLevel, obj.Respiration_range, obj.Oxygensaturation, obj.Temperature);
				objScore.Add(pData.Key, score);
			}

			foreach (var obj in objScore)
			{
				Console.WriteLine( "Score for Patient ID  " +  obj.Key.ToString()  + ": " + obj.Value.ToString());
			}
		}

	}


}




