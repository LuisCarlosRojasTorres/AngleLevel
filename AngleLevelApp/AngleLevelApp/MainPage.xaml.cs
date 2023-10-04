namespace AngleLevelApp;

public partial class MainPage : ContentPage
{
    double Ax, Ay, Az, angleV, angleL;

	public MainPage()
	{
		InitializeComponent();        
    }

    public void ToggleAccelerometer()
    {
        if (Accelerometer.Default.IsSupported)
        {
            if (!Accelerometer.Default.IsMonitoring)
            {
                // Turn on accelerometer
                Accelerometer.Default.ReadingChanged += Accelerometer_ReadingChanged;
                Accelerometer.Default.Start(SensorSpeed.UI);
            }
            else
            {
                // Turn off accelerometer
                Accelerometer.Default.Stop();
                Accelerometer.Default.ReadingChanged -= Accelerometer_ReadingChanged;
            }
        }
    }

    private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
    {
        // Update UI Label with accelerometer state
        AccelLabelX.Text = $"X: " + e.Reading.Acceleration.X.ToString("#.##");
        AccelLabelY.Text = $"Y: " + e.Reading.Acceleration.Y.ToString("#.##");
        AccelLabelZ.Text = $"Z: " + e.Reading.Acceleration.Z.ToString("#.##");

        Ax = e.Reading.Acceleration.X;
        Ay = e.Reading.Acceleration.Y;
        Az = e.Reading.Acceleration.Z;

        angleV = Math.Asin(Ay)*180/Math.PI;

        AngleV.Text = "AngleV: " + this.angleV.ToString("#.#");
    }

    private void Switch_Accel_Toggled(object sender, ToggledEventArgs e)
    {
        if (Accelerometer.Default.IsSupported)
        {
            if (Switch_Accel.IsToggled)
            {
                // Turn on accelerometer
                Accelerometer.Default.ReadingChanged += Accelerometer_ReadingChanged;
                Accelerometer.Default.Start(SensorSpeed.UI);
            }
            else
            {
                // Turn off accelerometer
                Accelerometer.Default.Stop();
                Accelerometer.Default.ReadingChanged -= Accelerometer_ReadingChanged;
            }
        }

    }
}

