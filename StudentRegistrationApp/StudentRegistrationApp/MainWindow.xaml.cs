using System.Windows;
using System.Windows.Controls;

namespace StudentRegistrationApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // ==================== SIMPAN ====================
        private void BtnSimpan_Click(object sender, RoutedEventArgs e)
        {
            // Validasi NIM
            if (string.IsNullOrWhiteSpace(txtNim.Text))
            {
                MessageBox.Show("NIM harus diisi!", "Validasi",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                txtNim.Focus();
                return;
            }

            // Validasi Nama
            if (string.IsNullOrWhiteSpace(txtNama.Text))
            {
                MessageBox.Show("Nama harus diisi!", "Validasi",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                txtNama.Focus();
                return;
            }

            // Validasi Program Studi
            if (cmbProdi.SelectedItem == null)
            {
                MessageBox.Show("Pilih program studi!", "Validasi",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Validasi Jenis Kelamin
            if (rbLaki.IsChecked != true && rbPerempuan.IsChecked != true)
            {
                MessageBox.Show("Pilih jenis kelamin!", "Validasi",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Ambil data
            string nim = txtNim.Text.Trim();
            string nama = txtNama.Text.Trim();
            string prodi = (cmbProdi.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "";
            string jenisKelamin = rbLaki.IsChecked == true ? "Laki-laki" : "Perempuan";

            // Format data dengan ikon
            string data = $"👤  {nim}  |  {nama}  |  {prodi}  |  {jenisKelamin}";
            lstMahasiswa.Items.Add(data);

            UpdateCounter();

            MessageBox.Show("Data mahasiswa berhasil disimpan!", "Informasi",
                MessageBoxButton.OK, MessageBoxImage.Information);

            // Auto reset form setelah simpan
            ResetForm();
        }

        // ==================== RESET ====================
        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            txtNim.Clear();
            txtNama.Clear();
            cmbProdi.SelectedIndex = -1;
            rbLaki.IsChecked = false;
            rbPerempuan.IsChecked = false;
            txtNim.Focus();
        }

        // ==================== HAPUS ====================
        private void BtnHapus_Click(object sender, RoutedEventArgs e)
        {
            if (lstMahasiswa.SelectedItem != null)
            {
                var result = MessageBox.Show(
                    "Apakah Anda yakin ingin menghapus data ini?",
                    "Konfirmasi Hapus",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    lstMahasiswa.Items.Remove(lstMahasiswa.SelectedItem);
                    UpdateCounter();

                    MessageBox.Show("Data berhasil dihapus!", "Informasi",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Pilih data yang ingin dihapus!", "Validasi",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // ==================== COUNTER ====================
        private void UpdateCounter()
        {
            txtCounter.Text = $"Jumlah Mahasiswa: {lstMahasiswa.Items.Count}";
        }
    }
}