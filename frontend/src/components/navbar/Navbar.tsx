import "./Navbar.scss";
import { Menu, Close } from "@mui/icons-material";
import { useState } from "react";
import { Link } from "react-router-dom";

const Navbar: React.FC = () => {
  const [open, setOpen] = useState<boolean>(false);

  const toggleNavbar = () => {
    if (window.innerWidth < 500) {
      setOpen(!open);
    }
  };

  const menuStyle = open ? "menu open" : "menu"
  return (
    <div className="navbar">
      <div className="brand">Pet Store</div>
      <div className="hamburger">
        <Menu onClick={toggleNavbar} />
      </div>
      <div className={menuStyle}>
        <ul>
          <Close className="close" onClick={toggleNavbar} />
          <li onClick={toggleNavbar}>
            <Link to="/">Home</Link>
          </li>
          <li onClick={toggleNavbar}>
            <Link to="/products">Products</Link>
          </li>
          <li onClick={toggleNavbar}>
            <Link to="/products/add">Add Product</Link>
          </li>
        </ul>
      </div>
    </div>
  );
};

export default Navbar;
