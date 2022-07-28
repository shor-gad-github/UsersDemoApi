import { LogoIcon } from "./JsonServerCrud/assets/icons"
import CrudUser from "./JsonServerCrud/components/CrudUser"
import "./JsonServerCrud/styles/App.css"

function App() {
  return (
    <>
      <header>
        <div className='header__content'>
          <div className='logo'>
            <LogoIcon />
            <strong>JSON SERVER API</strong>
          </div>
        </div>
      </header>
      <main>
        <CrudUser />
      </main>
    </>
  )
}

export default App
