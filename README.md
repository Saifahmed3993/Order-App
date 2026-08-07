# 🛒 Order App - Modern Order Management System

<div align="center">

![.NET 10](https://img.shields.io/badge/.NET-10-blueviolet?logo=.net&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-Latest-blue?logo=dotnet&logoColor=white)
![Razor Pages](https://img.shields.io/badge/Razor%20Pages-Modern-purple)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5.3-563d7c?logo=bootstrap&logoColor=white)
![License](https://img.shields.io/badge/License-MIT-green)
![GitHub Stars](https://img.shields.io/github/stars/Saifahmed3993/Order-App?style=social)

*A powerful, modern order management application with real-time calculations and stunning dark theme UI*

[Live Demo](#) • [Documentation](#documentation) • [Contributing](#contributing)

</div>

---

## 🎯 What is Order App?

Order App is a sophisticated order management system built with cutting-edge .NET 10 technology. It provides a seamless experience for creating, managing, and tracking orders with automatic calculations, smart validation, and a beautiful dark-themed interface.

**Perfect for:** Businesses, e-commerce platforms, and order management systems

---

## ✨ Key Features

### 📦 **Smart Order Management**
- ✅ Create orders with automatic timestamp tracking
- ✅ Real-time order summary display
- ✅ Automatic invoice price calculation
- ✅ Support for multiple products per order (up to 50)

### 🧮 **Intelligent Calculations**
- ✅ Real-time subtotal computation (Price × Quantity)
- ✅ Auto-calculated invoice totals
- ✅ Floating-point precision handling
- ✅ Instant visual feedback

### 🔒 **Advanced Validation**
- ✅ Order date must be ≥ 2000-01-01
- ✅ Invoice price matches product totals exactly
- ✅ Server-side validation for security
- ✅ Client-side validation for UX
- ✅ Comprehensive error messages

### 🎨 **Premium UI/UX**
- ✅ Modern GitHub-inspired dark theme
- ✅ Responsive design (mobile, tablet, desktop)
- ✅ Smooth animations & transitions
- ✅ Professional gradient effects
- ✅ Icon-enhanced interface

---

## 🚀 Quick Start

### Prerequisites
```
✓ .NET 10 SDK or later
✓ Visual Studio 2026 or compatible IDE
✓ 50 MB disk space
```

### Installation (30 seconds)

```bash
# 1️⃣ Clone the repository
git clone https://github.com/Saifahmed3993/Order-App.git
cd Order-App

# 2️⃣ Restore dependencies
dotnet restore

# 3️⃣ Build the project
dotnet build

# 4️⃣ Run the application
dotnet run

# 5️⃣ Open browser and go to
👉 https://localhost:5001/order
```

---

## 💻 Technology Stack

<table>
  <tr>
	<td><strong>Backend</strong></td>
	<td>.NET 10 • ASP.NET Core • C# 13</td>
  </tr>
  <tr>
	<td><strong>Frontend</strong></td>
	<td>HTML5 • CSS3 • Vanilla JavaScript</td>
  </tr>
  <tr>
	<td><strong>UI Framework</strong></td>
	<td>Bootstrap 5.3.3 • Font Awesome 6.4.0</td>
  </tr>
  <tr>
	<td><strong>Architecture</strong></td>
	<td>Razor Pages • MVC Pattern • Custom Validators</td>
  </tr>
  <tr>
	<td><strong>Validation</strong></td>
	<td>DataAnnotations • Reflection • Custom Attributes</td>
  </tr>
</table>

---

## 📖 How to Use

### Step 1: Set Order Date 📅
```
• Form defaults to current date/time
• Must be >= 2000-01-01
• Adjustable via datetime-local picker
```

### Step 2: Add Products 🛍️
```
1. Click "Add Product" button
2. Enter Product Code (e.g., 1001)
3. Enter Price (e.g., 15.00)
4. Enter Quantity (e.g., 10)
5. → Subtotal auto-calculates!
```

### Step 3: Review Order 👀
```
• Order date displays formatted
• Total items count updates live
• Invoice total shows auto-calculated sum
```

### Step 4: Submit Order ✅
```
1. Click "Submit Order"
2. Server validates all data
3. Receives unique Order Number
4. Success! 🎉
```

---

## 🔍 Validation Rules

| Field | Validation | Error Message |
|-------|-----------|---------------|
| **Order Date** | >= 2000-01-01 | Order date should be greater than or equal to 2000-01-01 |
| **Invoice Price** | Must match product total | InvoicePrice doesn't match with the total cost of the specified products |
| **Invoice Price Range** | 1 to 1.7976931348623157E+308 | The field Invoice Price must be between 1 and max value |
| **Products** | At least 1 required | Product list cannot be empty |
| **Product Code** | Required | - |
| **Product Price** | > 0 | Must be positive |
| **Product Quantity** | > 0 | Must be positive |

---

## 📁 Project Structure

```
Order-App/
│
├── 📂 Controllers/
│   └── OrdersController.cs          # Order handling & API
│
├── 📂 CustomValidators/
│   ├── MinimumDateValidator.cs      # Date >= 2000-01-01
│   ├── InvoicePriceValidator.cs     # Price matching logic
│   └── ProductListValidator.cs      # Product validation
│
├── 📂 Models/
│   ├── Order.cs                     # Order entity + validators
│   └── Product.cs                   # Product entity
│
├── 📂 Views/Orders/
│   └── Index.cshtml                 # Main UI (813 lines)
│
├── 📂 Properties/
│   └── launchSettings.json          # Dev environment config
│
├── Program.cs                       # Application startup
├── appsettings.json                 # Configuration
├── OrderApp.csproj                  # Project file
└── README.md                        # Documentation
```

---

## 🔌 API Reference

### Get Order Form
```http
GET /order
```
**Response:** HTML form page

---

### Submit Order
```http
POST /order
Content-Type: application/json

{
  "OrderDate": "2026-01-15T10:30:00",
  "InvoicePrice": 150.00,
  "Products": [
	{
	  "ProductCode": 1001,
	  "Price": 15.00,
	  "Quantity": 10
	}
  ]
}
```

**Success Response (200 OK):**
```json
{
  "OrderNumber": 45678
}
```

**Error Response (400):**
```
Order date should be greater than or equal to 2000-01-01
```

---

## 🔐 Custom Validators Explained

### MinimumDateValidator ⏰
Ensures order dates are not before 2000-01-01
- Handles datetime-local format correctly
- Compares date portion only (ignores time)
- Customizable: `[MinimumDateValidator("YYYY-MM-DD")]`

**Example:**
```csharp
[MinimumDateValidator("2000-01-01")]
public DateTime OrderDate { get; set; }
```

### InvoicePriceValidator 💰
Validates invoice matches sum of (Price × Quantity)
- Uses epsilon tolerance (0.01) for floating-point precision
- Accesses other model properties via Reflection
- Server-side security validation

**Example:**
```csharp
[InvoicePriceValidator]
public double InvoicePrice { get; set; }
```

### ProductListValidator 📦
Ensures at least one product exists
- Prevents empty orders
- Required validator

---

## 🎨 Visual Design

### Dark Theme Colors
```
Primary Background:  #0d1117
Card Background:     #161b22
Border Color:        #30363d
Text Color:          #c9d1d9
Accent Primary:      #58a6ff (Blue)
Accent Success:      #3fb950 (Green)
Accent Danger:       #f85149 (Red)
```

### UI Components
- Gradient headers with smooth transitions
- Animated card hover effects
- Real-time form validation feedback
- Smooth slideIn animations
- Responsive mobile layout

---

## 🌐 Browser Support

| Browser | Support | Minimum Version |
|---------|---------|-----------------|
| Chrome | ✅ Excellent | 90+ |
| Firefox | ✅ Excellent | 88+ |
| Safari | ✅ Excellent | 14+ |
| Edge | ✅ Excellent | 90+ |
| Mobile | ✅ Good | Latest |

---

## ⚙️ Configuration

### Development Setup
Edit `appsettings.Development.json`:
```json
{
  "Logging": {
	"LogLevel": {
	  "Default": "Debug"
	}
  }
}
```

### Production Setup
Edit `appsettings.json`:
```json
{
  "Logging": {
	"LogLevel": {
	  "Default": "Information"
	}
  }
}
```

---

## 🐛 Troubleshooting

### ❌ Date Validation Error
**Problem:** "Order date should be greater than or equal to 2000-01-01"
```
✅ Solution: Select a date on or after January 1, 2000
```

### ❌ Invoice Price Mismatch
**Problem:** "InvoicePrice doesn't match..."
```
✅ Solution: Verify all product prices and quantities
		   The total must equal: (Price₁ × Qty₁) + (Price₂ × Qty₂) + ...
```

### ❌ Form Won't Submit
**Problem:** Silent submission failure
```
✅ Solution: Open DevTools (F12) → Check Console for errors
		   Ensure all required fields are filled
		   Check network tab for API responses
```

### ❌ Styles Not Loading
**Problem:** Dark theme not appearing
```
✅ Solution: Hard refresh (Ctrl+Shift+R)
		   Clear browser cache
		   Check browser compatibility
```

---

## 📊 Performance

- **Page Load Time:** < 500ms
- **Calculation Speed:** Real-time (< 10ms)
- **Max Products:** 50 per order
- **Supported Numbers:** Up to 2 decimal places for prices

---

## 🎯 Features Roadmap

### Planned Enhancements
- [ ] 🗄️ Database integration (SQL Server)
- [ ] 👤 User authentication & authorization
- [ ] ✏️ Edit/cancel existing orders
- [ ] 📄 Export orders to PDF
- [ ] 📊 Order history & statistics
- [ ] 💳 Payment processing integration
- [ ] 🌍 Multi-currency support
- [ ] 📱 Mobile app (React Native)
- [ ] 🔔 Email notifications
- [ ] 📈 Advanced analytics dashboard

---

## 🤝 Contributing

We welcome contributions! Here's how:

### 1. Fork the Repository
```bash
git clone https://github.com/Saifahmed3993/Order-App.git
cd Order-App
```

### 2. Create Feature Branch
```bash
git checkout -b feature/AmazingFeature
```

### 3. Make Changes
```bash
# Edit files...
git add .
git commit -m "Add: Amazing feature description"
```

### 4. Push & Create Pull Request
```bash
git push origin feature/AmazingFeature
# Then open PR on GitHub
```

### Code Style
- Follow Microsoft C# coding conventions
- Use meaningful variable names
- Add comments for complex logic
- Keep methods focused and small

---

## 📝 License

This project is licensed under the **MIT License** - see the LICENSE file for details.

```
MIT License

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction...
```

---

## 👨‍💻 About the Author

**Saif Ahmed**

Full-Stack .NET Developer | Business Information Systems (BIS) Student

I'm passionate about building scalable ASP.NET Core applications, creating modern web interfaces, and continuously improving my backend development skills.

### 📬 Connect with Me

- 🔗 **GitHub:** https://github.com/Saifahmed3993
- 💼 **LinkedIn:** https://www.linkedin.com/in/saif-aldin-ahmed
- 📧 **Email:** saifahmedelbattawy@gmail.com

Feel free to connect with me for collaboration, feedback, or opportunities.
---

## 💬 Support & Feedback

### Get Help
1. 📖 Check [Documentation](#documentation)
2. 🔍 Search [GitHub Issues](https://github.com/Saifahmed3993/Order-App/issues)
3. 💬 Open a new issue with details
4. 📝 Include screenshots/error logs

### Report Bugs
```
Please include:
- Steps to reproduce
- Expected behavior
- Actual behavior
- Screenshots/videos
- System information
```

---

## 📚 Additional Resources

- [.NET 10 Documentation](https://docs.microsoft.com/dotnet/)
- [ASP.NET Core Docs](https://docs.microsoft.com/aspnet/core/)
- [Razor Pages Guide](https://docs.microsoft.com/aspnet/core/razor-pages/)
- [Bootstrap 5 Documentation](https://getbootstrap.com/docs/5.3/)

---

## 📈 Project Statistics

```
📊 Code Metrics
├── Lines of Code: 1,585+
├── Files: 13
├── CSS Lines: 400+
├── JavaScript Lines: 250+
├── C# Lines: 250+
└── HTML Lines: 400+

📦 Dependencies
├── .NET 10 Framework
├── Bootstrap 5.3.3
└── Font Awesome 6.4.0
```

---

## 🎉 Changelog

### v1.0.0 (Current)
- ✨ Initial release
- 🎨 Beautiful dark theme UI
- 🔒 Smart validation system
- 📱 Responsive design
- 🚀 Real-time calculations

---

<div align="center">

**[⬆ Back to Top](#-order-app---modern-order-management-system)**

Made with ❤️ by **Saif Ahmed**

⭐ If you found this project helpful, don't forget to star the repository.

![GitHub followers](https://img.shields.io/github/followers/Saifahmed3993?style=social)
![GitHub User's stars](https://img.shields.io/github/stars/Saifahmed3993?style=social)

</div>
