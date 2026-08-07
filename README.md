# Order App 📦

A modern, feature-rich order management application built with ASP.NET Core and Razor Pages. Create and manage orders with dynamic product selection, automatic invoice calculation, and comprehensive validation.

## Features ✨

- **Order Management**
  - Create new orders with date and time tracking
  - Automatic invoice price calculation
  - Real-time order summary display

- **Product Management**
  - Add/remove products dynamically
  - Automatic subtotal calculation (Price × Quantity)
  - Support for up to 50 products per order
  - Validation for product codes, prices, and quantities

- **Smart Validation** 🔍
  - Order date must be >= 2000-01-01
  - Invoice price must match calculated product totals (with floating-point tolerance)
  - Real-time validation feedback
  - Server-side validation for data integrity

- **Dark Theme UI** 🌙
  - Modern GitHub-inspired dark theme
  - Responsive design with Bootstrap 5.3
  - Smooth animations and transitions
  - Font Awesome icons
  - Mobile-friendly interface

## Technology Stack 🛠️

- **Backend**
  - .NET 10
  - ASP.NET Core (Razor Pages)
  - C# with custom validators
  - Reflection for dynamic property access

- **Frontend**
  - HTML5
  - CSS3 (Custom dark theme)
  - Vanilla JavaScript (no dependencies)
  - Bootstrap 5.3.3
  - Font Awesome 6.4.0

- **Architecture**
  - MVC pattern with custom validation attributes
  - Client-side calculations with server-side verification
  - RESTful API endpoints

## Project Structure 📁

```
OrderApp/
├── Controllers/
│   └── OrdersController.cs          # Main order handling controller
├── CustomValidators/
│   ├── MinimumDateValidator.cs      # Validates order date >= 2000-01-01
│   ├── InvoicePriceValidator.cs     # Validates invoice matches product total
│   └── ProductListValidator.cs      # Validates product list
├── Models/
│   ├── Order.cs                     # Order model with validation attributes
│   └── Product.cs                   # Product model
├── Views/Orders/
│   └── Index.cshtml                 # Main order form view
├── Properties/
│   └── launchSettings.json          # Application settings
├── Program.cs                       # Application startup configuration
└── appsettings.json                 # Configuration file
```

## Getting Started 🚀

### Prerequisites
- .NET 10 SDK or later
- Visual Studio 2026 (or any .NET 10 compatible IDE)
- Git (for version control)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/Saifahmed3993/Order-App.git
   cd Order-App
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Build the project**
   ```bash
   dotnet build
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

5. **Open in browser**
   Navigate to `https://localhost:5001/order` (or the URL shown in your terminal)

## Usage 📝

### Creating an Order

1. **Set Order Date**
   - The form defaults to the current date/time
   - Date must be >= 2000-01-01
   - Adjust as needed

2. **Add Products**
   - Click "Add Product" button
   - Enter product details:
	 - **Product Code**: Unique identifier
	 - **Price**: Unit price (2 decimal places)
	 - **Quantity**: Number of units
   - Subtotal auto-calculates: Price × Quantity

3. **Review Order**
   - Order summary shows:
	 - Order date and time
	 - Total items count
	 - Invoice total (auto-calculated)

4. **Submit Order**
   - Click "Submit Order" to validate and create
   - Server validates all data
   - Returns order number on success

### Validation Rules ✅

| Field | Rule | Error Message |
|-------|------|---------------|
| Order Date | >= 2000-01-01 | "Order date should be greater than or equal to 2000-01-01" |
| Invoice Price | Matches product total | "InvoicePrice doesn't match with the total cost of the specified products in the order." |
| Invoice Price | 1 to 1.7976931348623157E+308 | "The field Invoice Price must be between 1 and 1.7976931348623157E+308." |
| Products | At least one product | Required validator |
| Product Code | Required | - |
| Product Price | > 0 | - |
| Product Quantity | > 0 | - |

## API Endpoints 🔌

### GET /order
Displays the order creation form

**Response:** HTML form page

### POST /order
Submits order for processing

**Request Body:**
```json
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

**Validation Error (400 Bad Request):**
```
Order date should be greater than or equal to 2000-01-01
InvoicePrice doesn't match with the total cost...
```

## Validators Deep Dive 🔐

### MinimumDateValidator
- Ensures order dates are not before 2000-01-01
- Compares date portion only (ignores time zone differences)
- Customizable via `[MinimumDateValidator("YYYY-MM-DD")]` attribute

### InvoicePriceValidator
- Validates invoice price matches sum of (Price × Quantity) for all products
- Uses epsilon tolerance (0.01) for floating-point precision
- Accesses other model properties via Reflection

### ProductListValidator
- Ensures at least one product is included
- Prevents empty orders

## Key Features Implementation 💡

### Dynamic Product Addition
- JavaScript tracks product index
- Supports up to 50 products
- Automatic row removal with animation
- Empty state message when no products

### Real-time Calculations
- JavaScript calculates subtotals instantly
- Auto-updates invoice total
- Visual feedback with animations

### Responsive Design
- Mobile-optimized dark theme
- Adapts to 768px and 480px breakpoints
- Touch-friendly buttons and inputs

## Browser Support 🌐

- Chrome/Chromium 90+
- Firefox 88+
- Safari 14+
- Edge 90+

## Configuration ⚙️

Edit `appsettings.json` to customize:
- Database connections
- Logging levels
- Application settings

## Contributing 🤝

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## Known Limitations ⚠️

- Maximum 50 products per order
- Invoice price is readonly (auto-calculated)
- No order persistence (stored in-memory only)
- No user authentication

## Future Enhancements 🎯

- [ ] Add order history/persistence with database
- [ ] User authentication and authorization
- [ ] Order editing and cancellation
- [ ] Export orders to PDF
- [ ] Order status tracking
- [ ] Payment processing integration
- [ ] Multi-currency support
- [ ] Advanced filtering and search

## Troubleshooting 🔧

### Date Validation Error
**Problem:** "Order date should be greater than or equal to 2000-01-01"
**Solution:** Ensure the selected date is not before 2000-01-01

### Invoice Price Mismatch
**Problem:** "InvoicePrice doesn't match with the total cost..."
**Solution:** Verify all product prices and quantities are entered correctly. The invoice total must exactly match the sum of (Price × Quantity) for each product.

### Form Not Submitting
**Problem:** Form submission fails silently
**Solution:** Check browser console (F12) for JavaScript errors. Ensure all required fields are filled.

## Performance Tips 📊

- Keep products under 50 items for optimal performance
- Use numbers with up to 2 decimal places for prices
- Large quantity values are supported

## License 📄

This project is open source and available under the MIT License.

## Author 👤

**Saif Ahmed**
- GitHub: [@Saifahmed3993](https://github.com/Saifahmed3993)

## Support 💬

For issues, questions, or suggestions:
1. Check existing issues on GitHub
2. Create a new issue with detailed description
3. Include steps to reproduce bugs
4. Attach screenshots if applicable

---

**Last Updated:** January 2026
**Version:** 1.0.0
