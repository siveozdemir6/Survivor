# 🏝️ Survivor Web API

Bu proje, Survivor yarışma konseptine dayalı bir ASP.NET Core Web API uygulamasıdır. Yarışmacılar (Competitors) ve kategoriler (Categories) arasında bire-çok (one-to-many) ilişkili bir yapı üzerine kuruludur.

## 📌 Proje Özellikleri

- ✅ Competitor ve Category varlıkları
- ✅ Entity'ler `BaseEntity` üzerinden türemiştir (Id, CreatedDate, ModifiedDate, IsDeleted).
- ✅ CRUD (Create, Read, Update, Delete) işlemleri için API endpoint'leri
- ✅ Silme işlemleri için soft delete (IsDeleted flag)

📬 API Endpoint'leri
CompetitorController
Method	Route	Açıklama
GET	/api/competitor	Tüm yarışmacıları getir
GET	/api/competitor/{id}	Belirli yarışmacıyı getir
GET	/api/competitor/category/{categoryId}	Belirli kategorideki yarışmacıları getir
POST	/api/competitor	Yeni yarışmacı oluştur
PUT	/api/competitor/{id}	Yarışmacıyı güncelle
DELETE	/api/competitor/{id}	Yarışmacıyı sil (soft delete)

CategoryController
Method	Route	Açıklama
GET	/api/category	Tüm kategorileri getir
GET	/api/category/{id}	Belirli kategoriyi getir
POST	/api/category	Yeni kategori oluştur
PUT	/api/category/{id}	Kategoriyi güncelle
DELETE	/api/category/{id}	Kategoriyi sil (soft delete)
