Sistem Cuti Karyawan 📝

Aplikasi web sederhana berbasis ASP.NET Core MVC yang digunakan untuk mengelola pengajuan cuti karyawan.
Project ini menggunakan Entity Framework Core dengan SQLite sebagai database.

✨ Fitur Utama

CRUD Data Pengajuan Cuti (Create, Read, Update, Delete).

Fitur pencarian karyawan berdasarkan nama.

Validasi tanggal cuti (tidak boleh tanggal selesai lebih kecil dari tanggal mulai).

Status cuti: Approved atau Declined.

Tampilan menggunakan Bootstrap 5 dengan styling custom agar modern dan responsif.

🛠️ Teknologi yang Digunakan

ASP.NET Core 9.0

Entity Framework Core

SQLite

Bootstrap 5

C# sebagai bahasa pemrograman

📚 Pembelajaran dari Project Ini

Mempelajari pola MVC (Model-View-Controller) di ASP.NET.

Cara menghubungkan aplikasi dengan database menggunakan Entity Framework Core.

Membuat validasi sederhana di sisi server.

Menggunakan Bootstrap untuk UI/UX yang lebih baik.

👤 Author

Delin Herliana Pasha

🚀 Cara Menjalankan Project

Clone repository ini:
git clone https://github.com/DelinGithub20/sistemcutikaryawan.git
cd sistemcutikaryawan/sistemcutikaryawan

Jalankan migrasi database:
dotnet ef database update

Jalankan aplikasi:
dotnet run

Buka di browser:
http://localhost:5264/
